using FluentValidation.Results;

namespace Blog.Application.Bus.Notify
{
    public interface INotifier
    {
        void Notice<T>(string content);

        void Notice(string title, string content);

        void NoticeErrors(ValidationResult result);

        void NoticeError(string content);
    }
}
