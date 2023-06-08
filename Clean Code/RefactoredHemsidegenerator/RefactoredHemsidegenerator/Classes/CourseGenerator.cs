using RefactoredHemsidegenerator.Interfaces;

namespace RefactoredHemsidegenerator.Classes
{
    public class CourseGenerator : ICourseGenerator
    {
        public string[] courses;

        public CourseGenerator(string[] courses)
        {
            this.courses = courses;
        }

        public string[] Courses
        {
            get { return this.courses; }
        }

        public void TrimCourses()
        {
            foreach (string course in courses)
            {
                course.Trim();
            }
        }

        public string AddHTMLTags()
        {
            string HTMLTaggedCourses = "";

            foreach (string course in courses)
            {
                HTMLTaggedCourses += "<p>" + course[0].ToString().ToUpper() + course.Substring(1).ToLower() + "</p>\n";
            }

            return HTMLTaggedCourses;
        }
    }
}
