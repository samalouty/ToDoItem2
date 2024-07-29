using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoItem2.Domain
{
    public class ToDoItem
    {
        [Key]
        public int taskNum { get; set; } = 0;

        public Boolean done { get; set; } = false;
        public string taskName { get; set; }

/*        public User user { get; set; }
*/


        public void ToggleDone()
        {
            done = !done;
        }

    }
}
