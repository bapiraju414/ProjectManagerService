using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.ServiceLayer;

namespace ProjectManagerTest.Load_Test
{
    public class MemoryTests : PerformanceTestStuite<MemoryTests>
    {
        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void GetTaskMemory_Test()
        {
            var projectmanagerController = new ProjectManagerController();
            var response = projectmanagerController.GetTasks();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void GetParentTaskMemory_Test()
        {
            var projectmanagerController = new ProjectManagerController();
            var response = projectmanagerController.GetParentTask();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void GetGetProjectDetailsMemory_Test()
        {
            var projectmanagerController = new ProjectManagerController();
            var response = projectmanagerController.GetProjectDetails();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void GetTasksByProjectIdMemory_Test()
        {
            var projectmanagerController = new ProjectManagerController();
            var response = projectmanagerController.GetTasksByProjectId(2);
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void GetUserByIdMemory_Test()
        {
            var projectmanagerController = new ProjectManagerController();
            var response = projectmanagerController.GetUserById(2);
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void GetTasksByIdMemory_Test()
        {
            var projectmanagerController = new ProjectManagerController();
            var response = projectmanagerController.GetTasksById(1);
        }
    }
}
