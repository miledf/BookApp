using BookApp.Domain.Dtos.SubjectRequest;
using BookApp.Infrastructure.Models;

namespace BookApp.Domain.Dtos.SubjectRequestMapper
{
    public static class SubjectRequestMapper
    {
        public static  Subject Map(this SubjectRequest.SubjectRequest subjectRequest)
        {
            return new Subject
            {
                Description = subjectRequest.Description
            };
        }

        public static SubjectDto Map(this Subject subject)
        {
            return new SubjectDto(subject.Id, subject.Description);
        }
    }
}
