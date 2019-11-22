using System;
using System.Windows.Input;

namespace VideoProject
{
    /// <summary>
    /// The command class
    /// </summary>
    public class Command : ICommand
    {
        private Action execute = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="execute">The action to exeute</param>
        public Command(Action execute)
        {
            this.execute = execute;
        } 

        /// <summary>
        /// The can execute changed event handler
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Gets whether the comamnd can be executed
        /// </summary>
        /// <param name="parameter">(Optional) Any parameter needed to determine if the command can execute</param>
        /// <returns>True if it can execute, false otherwise</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the provided action
        /// </summary>
        /// <param name="parameter">(Optional) Parameter to pass to the command</param>
        public void Execute(object parameter)
        {
            this.execute();
        }
    }
}
