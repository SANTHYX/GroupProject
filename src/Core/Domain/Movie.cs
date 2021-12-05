using Core.Types;

namespace Core.Domain
{
    public class Movie : Entity
    {
        public string FileName { get; set; }

        protected Movie()
        {

        }

        public Movie(string fileName)
        {
            FileName = fileName;
        }
    }
}
