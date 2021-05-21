using System;

namespace NexGenScreening.HccGyna.Infrastructure.Validation.Models
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationResultModel validationResultModel)
        {
            ValidationResultModel = validationResultModel;
        }

        public ValidationResultModel ValidationResultModel { get; }
    }
}
