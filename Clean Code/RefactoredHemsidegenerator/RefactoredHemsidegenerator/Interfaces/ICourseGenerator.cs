namespace RefactoredHemsidegenerator.Interfaces
{
    public interface ICourseGenerator
    {
        string[] Courses { get; }
        string AddHTMLTags();
        void TrimCourses();
    }
}