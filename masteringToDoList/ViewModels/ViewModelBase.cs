using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using masteringToDoList.WPF.Command;

namespace masteringToDoList.WPF.ViewModels
{
    public class ViewModelBase
    {
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), () => CanExecute));
            }
        }
        public bool CanExecute => true;

        public void MyAction()
        {

        }
    }
}
