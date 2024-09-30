using BookApp.Infrastructure.Models;

namespace BookApp.Domain.Dtos.SubjectRequest
{
    public static class SubjectRequestMapper
    {
        public static  Subject Map(this SubjectRequest subjectRequest)
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
