using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace VideoProject
{
    /// <summary>
    /// A class to assist in invoking an async task and notifying when complete.
    /// Provides helper function to access to the underlying task's status and exceptions.
    /// </summary>
    /// <typeparam name="TResult">The task return type</typeparam>
    public class TaskNotifier<TResult> : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskNotifier{TResult}"/> class.
        /// </summary>
        /// <param name="task">The task to run and notify on</param>
        public TaskNotifier(Task<TResult> task)
        {
            this.Task = task;
            if (!task.IsCompleted)
            {
                var x = this.WatchTaskAsync(task);
            }
        }

        /// <summary>
        /// The property changede event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets and sets the task
        /// </summary>
        public Task<TResult> Task { get; private set; }

        /// <summary>
        /// Gets the task's result
        /// </summary>
        public TResult Result
        {
            get
            {
                return (this.Task.Status == TaskStatus.RanToCompletion) ? this.Task.Result : default(TResult);
            }
        }

        /// <summary>
        /// Gets the tasks status
        /// </summary>
        public TaskStatus Status
        {
            get { return this.Task.Status; }
        }

        /// <summary>
        /// Gets a value indicating whether the task has completed or not
        /// </summary>
        public bool IsCompleted
        {
            get { return this.Task.IsCompleted; }
        }

        /// <summary>
        /// Gets a value indicating whether the task has been cancelled
        /// </summary>
        public bool IsCanceled
        {
            get { return this.Task.IsCanceled; }
        }

        /// <summary>
        /// Gets a value indicating whether the task has faulted
        /// </summary>
        public bool IsFaulted
        {
            get { return this.Task.IsFaulted; }
        }

        /// <summary>
        /// Gets the tasks exception
        /// </summary>
        public AggregateException Exception
        {
            get { return this.Task.Exception; }
        }

        /// <summary>
        /// Awaits the task and notifies various property changes based on the resulting task's status
        /// </summary>
        /// <param name="task">The task to await</param>
        /// <returns>An await task</returns>
        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
                // Exception caught - a faulted and exception property changed event will be notified
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsCompleted"));

            if (task.IsCanceled)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsCanceled"));
            }
            else if (task.IsFaulted)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsFaulted"));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Exception"));
            }
            else
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }
    }
}
