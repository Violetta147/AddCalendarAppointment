using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddCalendarAppointment.DTO
{
    public class Appointment_DTO
    {
        public int? Id { get; set; }

        public string CreatorName { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public bool isGroup { get; set; }

        public int? createdBy { get; set; }

    }
}
