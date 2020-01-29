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

        private ModuleListModel moduleListModel = ModuleListModel.Instance;
        private TimetableModule player = new TimetableModule();

        private bool _IsGrounded = false;
        private bool _IsGameOver = false;


        #region Commands

        private ICommand _StartCommand;
        public ICommand StartCommand

        {
            get
            {
                if (_StartCommand == null)

                {
                    _StartCommand = new ActionCommand(dummy => this.StartGame(), null);
                }
                return _StartCommand;
            }

        }

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

        public TimetableTetris()
        {

        }

        public void StartGame()
        {
            Task gameTask = Task.Factory.StartNew(() =>
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
        }

        private void SetUpTimetable()
        {
            moduleListModel.ModuleList.Clear();
        }

        private void Spawn()
        {
            player = new TimetableModule() { ID = new Random().Next(), StartTime = Globals.StartTime.ToString(@"hh\:mm"),
            EndTime = Globals.StartTime.Add(new TimeSpan(1, 0, 0)).ToString(@"hh\:mm")
            };

            moduleListModel.ModuleList.Add(player);
            _IsGrounded = false;
        }

        public void Down()
        { 
            TimeSpan start = TimeSpan.Parse(player.StartTime);
            TimeSpan end = TimeSpan.Parse(player.EndTime);
            start = start.Add(Globals.TimeSubdivision);
            end = end.Add(Globals.TimeSubdivision);

            if (CheckGround(end))
            {
                _IsGrounded = true;
            }
            else
            {
                player.StartTime = start.ToString(@"hh\:mm");
                player.EndTime = end.ToString(@"hh\:mm");

            }
        }

        public bool CheckGround(TimeSpan end)
        {
            if (end > Globals.EndTime || CheckBlock(end))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckBlock(TimeSpan end)
        {
            int day = Convert.ToInt32(player.Day);

            foreach(var ttm in moduleListModel.ModuleList)
            {

                if (ttm != player && day == Convert.ToInt32(ttm.Day) && TimeSpan.Parse(ttm.StartTime) < end)
                {
                    return true;
                }
            }
            return false;
        }

        public void Left()
        {
            int d = Convert.ToInt32(player.Day);
            if (d >= 1)
            {
                d -= 1;
                player.Day = Convert.ToString(d);
            }
        }

        public void Right()
        {
            int d = Convert.ToInt32(player.Day);
            if(d < Globals.weekdays-1)
            {
                d += 1;
                player.Day = Convert.ToString(d);
            }
        }
    }
}
