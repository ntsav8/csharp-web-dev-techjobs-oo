using System;
using System.Collections.Generic;

namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; set; }
        private static int nextId = 1;
        public string Value { get; set; }

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType,
            CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override string ToString()
        {
            if (Name == "")
            {
                Name = "Data not available";
            }

            if (EmployerName.Value == "" || EmployerName.Value == null)
            {
                EmployerName.Value = "Data not available";
            }

            if (EmployerLocation.Value == "" || EmployerLocation.Value == null)
            {
                EmployerLocation.Value = "Data not available";
            }

            if (JobType.Value == "" || JobType.Value == null)
            {
                JobType.Value = "Data not available";
            }

            if (JobCoreCompetency.Value == "" || JobCoreCompetency.Value == null)
            {
                JobCoreCompetency.Value = "Data not available";
            }

            string output = $"ID: {Id} \n Name:{Name} \n Employer:{EmployerName.Value} \n " +
                $"Location:{EmployerLocation.Value} \n PositionType: {JobType.Value} \n " +
                $"CoreCompentency: {JobCoreCompetency.Value}\n";

            return output;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                Id == job.Id &&
                Name == job.Name &&
                EqualityComparer<Employer>.Default.Equals(EmployerName, job.EmployerName) &&
                EqualityComparer<Location>.Default.Equals(EmployerLocation, job.EmployerLocation) &&
                EqualityComparer<PositionType>.Default.Equals(JobType, job.JobType) &&
                EqualityComparer<CoreCompetency>.Default.Equals(JobCoreCompetency, job.JobCoreCompetency);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, EmployerName, EmployerLocation, JobType, JobCoreCompetency);
        }
    }
}
