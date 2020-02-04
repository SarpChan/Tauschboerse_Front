using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Frontend.ViewModel
{
    class TimetableTetris
    {
        InputQueue _InputQueue = new InputQueue();
        private ModuleListModel moduleListModel = ModuleListModel.Instance;
        private TimetableModule player = new TimetableModule();
        private Task _GameTask;
        private Task _QueueTask;

        private bool _IsGrounded = false;
        private bool _IsGameOver = false;
        public bool IsGameOver { get { return _IsGameOver; } }


        #region Commands
        private ICommand _LeftCommand;
        public ICommand LeftCommand

        {
            get
            {
                if (_LeftCommand == null)

                {
                    _LeftCommand = new ActionCommand(dummy => this.Left(), null);
                }
                return _LeftCommand;
            }

        }

        private ICommand _RightCommand;
        public ICommand RightCommand

        {
            get
            {
                if (_RightCommand == null)

                {
                    _RightCommand = new ActionCommand(dummy => this.Right(), null);
                }
                return _RightCommand;
            }

        }

        private ICommand _DownCommand;
        public ICommand DownCommand

        {
            get
            {
                if (_DownCommand == null)

                {
                    _DownCommand = new ActionCommand(dummy => this.Down(), null);
                }
                return _DownCommand;
            }

        }




        #endregion
        /// <summary>
        /// Ein kleines Extra das mit einer Bestimmtentastencombo aktiviert werden kann
        /// (Spoiler) Es ist Tetris mit unser LiveUpdateSystem fuer den Stundenplan
        /// </summary>
        public TimetableTetris()
        {

        }

        public void StartGame()
        {
            _GameTask = Task.Factory.StartNew(() =>
            {
                SetUpTimetable();
                GameThread();
            });
        }

        private void GameThread()
        {
            Spawn();

            while (!_IsGameOver)
            {
                if (_IsGrounded)
                {
                    Spawn();
                }

                Down();
                Thread.Sleep(200);
            }

            Thread.Sleep(200);
            KillGame();
        }

        private void SetUpTimetable()
        {
            moduleListModel.ModuleList.Clear();
        }

        private void Spawn()
        {
            _InputQueue.Enqueque(HandleSpawn);
        }

        private void HandleSpawn()
        {


            player = new TimetableModule()
            {
                ID = new Random().Next(),
                StartTime = Globals.StartTime.ToString(@"hh\:mm"),
                EndTime = Globals.StartTime.Add(new TimeSpan(1, 0, 0)).ToString(@"hh\:mm")
            };

            moduleListModel.ModuleList.Add(player);
            _IsGrounded = false;
        }

        /// <summary>
        /// Beendet Tetris
        /// </summary>
        public void KillGame()
        {
            _IsGameOver = true;
            moduleListModel.ClearList();
        }

        public void Down()
        {
            _InputQueue.Enqueque(HandleDown);
        }

        private void HandleDown()
        {
            if (!_IsGameOver)
            {
                TimeSpan start = TimeSpan.Parse(player.StartTime);
                TimeSpan end = TimeSpan.Parse(player.EndTime);
                var startBefore = start;
                start = start.Add(Globals.TimeSubdivision);
                end = end.Add(Globals.TimeSubdivision);

                if (CheckGround(start, end))
                {
                    if (startBefore == Globals.StartTime)
                    {
                        _IsGameOver = true;
                    }

                    _IsGrounded = true;
                    CheckForLineClear();
                }
                else
                {
                    player.StartTime = start.ToString(@"hh\:mm");
                    player.EndTime = end.ToString(@"hh\:mm");

                }
            }
        }

        private void CheckForLineClear()
        {
            List<TimetableModule> fullLines = new List<TimetableModule>();

            foreach (var ttm_1 in moduleListModel.ModuleList)
            {
                if (CheckForFullLine(ttm_1))
                {
                    fullLines.Add(ttm_1);
                }

            }

            foreach (var ttm in fullLines)
            {
                if (moduleListModel.ModuleList.Contains(ttm))
                {

                    DoLineClear(ttm);
                }
            }
        }

        private void DoLineClear(TimetableModule ttm)
        {

            List<TimetableModule> removeList = new List<TimetableModule>();
            TimeSpan s1 = TimeSpan.Parse(ttm.StartTime);
            TimeSpan e1 = TimeSpan.Parse(ttm.EndTime);

            TimeSpan div = e1.Subtract(s1);


            Task.Factory.StartNew(() =>
            {
                moduleListModel.ModuleList.Remove(ttm);
            }).Wait();

        }

        private bool CheckForFullLine(TimetableModule ttm_1)
        {

            TimeSpan start = TimeSpan.Parse(ttm_1.StartTime);
            TimeSpan end = TimeSpan.Parse(ttm_1.EndTime);

            for (int i = 0; i < Globals.weekdays; i++)
            {
                if (!CheckOnDay(start, end, i))
                {
                    return false;
                }

            }
            return true;
        }

        private bool CheckOnDay(TimeSpan start, TimeSpan end, int day)
        {
            foreach (var t in moduleListModel.ModuleList)
            {
                if (CheckBlockWithPlayer(start, end, day))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckGround(TimeSpan start, TimeSpan end)
        {
            if (end > Globals.EndTime || CheckBlock(start, end, Convert.ToInt32(player.Day)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckBlock(TimeSpan s1, TimeSpan e1, int day)
        {

            foreach (var ttm in moduleListModel.ModuleList)
            {

                TimeSpan s2 = TimeSpan.Parse(ttm.StartTime);
                TimeSpan e2 = TimeSpan.Parse(ttm.EndTime);

                if (ttm != player && day == Convert.ToInt32(ttm.Day)
                    && ((s1 > s2 && s1 < e2) || (e1 > s2 && e1 < e2) || (s1 == s2 && e1 == e2)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckBlockWithPlayer(TimeSpan s1, TimeSpan e1, int day)
        {
            foreach (var ttm in moduleListModel.ModuleList)
            {

                TimeSpan s2 = TimeSpan.Parse(ttm.StartTime);
                TimeSpan e2 = TimeSpan.Parse(ttm.EndTime);

                if (day == Convert.ToInt32(ttm.Day)
                    && ((s1 > s2 && s1 < e2) || (e1 > s2 && e1 < e2) || (s1 == s2 && e1 == e2)))
                {
                    return true;
                }
            }
            return false;
        }

        public void Left()
        {
            _InputQueue.Enqueque(HandleLeft);
        }

        private void HandleLeft()
        {

            if (!_IsGameOver)
            {
                int d = Convert.ToInt32(player.Day);
                TimeSpan end = TimeSpan.Parse(player.EndTime);
                TimeSpan start = TimeSpan.Parse(player.StartTime);


                if (d >= 1 && !CheckBlock(start, end, d - 1))
                {
                    d -= 1;
                    player.Day = Convert.ToString(d);
                }
            }
        }


        public void Right()
        {
            _InputQueue.Enqueque(HandleRight);
        }

        private void HandleRight()
        {

            if (!_IsGameOver)
            {
                int d = Convert.ToInt32(player.Day);
                TimeSpan end = TimeSpan.Parse(player.EndTime);
                TimeSpan start = TimeSpan.Parse(player.StartTime);

                if (d < Globals.weekdays - 1 && !CheckBlock(start, end, d + 1))
                {
                    d += 1;
                    player.Day = Convert.ToString(d);
                }
            }
        }
    }

    class InputQueue
    {
        private Thread _QueueThread;
        Queue<Action> _InputQueue = new Queue<Action>();

        public void Enqueque(Action e)
        {
            _InputQueue.Enqueue(e);

            if (_QueueThread == null || !_QueueThread.IsAlive)
            {
                _QueueThread = new Thread(() =>
                {
                    while (_InputQueue.Count != 0)
                    {
                        _InputQueue.Dequeue()();
                    }

                });

                _QueueThread.Start();
            }

        }
    }
}
