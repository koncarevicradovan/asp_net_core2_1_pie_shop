using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models
{
    public interface IFeedbackRepository
    {
        void AddFeedback(Feedback feedback);
    }
}
