using System;
using System.Threading.Tasks;

namespace VideoProject
{
    /// <summary>
    /// A class to assist in invoking an async task and notifying when complete.
    /// Provides helper function to access to the underlying task's status and exceptions.
    /// </summary>
    /// <typeparam name="TResult">The task return type</typeparam>
    public class TaskNotifier<TResult> : NotifyClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskNotifier{TResult}"/> class.
        /// </summary>
        /// <param name="task">The task to run and notify on</param>
        public TaskNotifier(Task<TResult> task)
        {
            this.Task = task;

            // If not complete, then watch and notify on task changes. Otherwise, there is no need to bother.
            if (!task.IsCompleted)
            {
                var x = this.WatchTaskAsync(task);
            }
        }

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
        /// Gets a value indicating whether the task is running
        /// </summary>
        public bool IsLoading
        {
            get { return !this.Task.IsCompleted; }
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
                // Wait for the task to complete
                await task;
            }
            catch
            {
                // Exception caught - a faulted and exception property changed event will be notified
            }

            // Notify of these general property changes
            this.NotifyChanged("Status");
            this.NotifyChanged("IsCompleted");
            this.NotifyChanged("IsLoading");

            if (task.IsCanceled)
            {
                // Task has been cancelled
                this.NotifyChanged("IsCanceled");
            }
            else if (task.IsFaulted)
            {
                // There was an error, notify the fault property
                this.NotifyChanged("IsFaulted");
                this.NotifyChanged("Exception");
            }
            else
            {
                // No error or cancelled, notify the result property
                this.NotifyChanged("Result");
            }
        }
    }
}
