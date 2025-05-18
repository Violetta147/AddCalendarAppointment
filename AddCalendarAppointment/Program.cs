using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddCalendarAppointment.Services;
using AddCalendarAppointment.Services.Interfaces;
using AddCalendarAppointment.Forms;

namespace AddCalendarAppointment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            var services = new ServiceCollection();
            services.AddScoped<OOAD_AddCalendarAppointmentEntities>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<IReminderService, ReminderService>();
            services.AddScoped<MainForm>();
            services.AddScoped<ReminderForm>();
            services.AddScoped<ReminderControl>();
            services.AddScoped<AppointmentForm>();
            services.AddScoped<Login>();
            services.AddScoped<Register>();
            var serviceProvider = services.BuildServiceProvider();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
    }
}
