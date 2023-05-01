$(document).ready(function () {

    const RenderTasks = (tasks, container) => {
        container.empty();

        for (const task of tasks) {
            const statusText = task.status === 0 ? "In Progress" : "Completed";
            const bgColorClass = task.status === 0 ? "bg-primary" : "bg-success";
            const borderColorClass = task.status === 0 ? "border-primary" : "border-success";
            const taskCard = $(`
            <div class="d-flex flex-column flex-wrap my-2 border rounded p-3" style="max-width: 25rem; margin-inline: 1rem;">  
              <div class="d-flex border ${bgColorClass} ${borderColorClass} bg-opacity-25 rounded px-2 align-items-center justify-content-center mb-3" style="width:fit-content;">
                    <p class="text-center my-2">${statusText}</p>
              </div>
              <div>
                 <p class="" style="font-weight: 600;">${task.name}</p>
                 <p class="" style="font-weight: 400;">${task.description}</p>
              </div>
              <div>
              <p class="" style="font-weight: 500;">Is realized by ${task.employeeId}</p>
              </div>
              <div>
               <a href="/ProjectTask/${task.id}/Edit" class="btn btn-outline-dark details-button">Manage task</a>
              </div>
            </div>`);
            container.append(taskCard);
        }
    }



    const LoadTasks = () => {
        const container = $("#tasks")
        const projectId = container.data("id");

        $.ajax({
            url: `/Project/${projectId}/ProjectTask`,
            type: 'get',
            success: function (data) {
                if (!data.length) {
                    container.html("There are no tasks for this project")
                } else {
                    RenderTasks(data, container)
                }
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        })
    }



    LoadTasks()


    $("#createProjectTaskModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created task")
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        })
    });
});
