$(document).ready(function () {

    const RenderTasks = (tasks, container) => {
        container.empty();

        for (const task of tasks) {
            const statusText = task.status === 0 ? "In Progress" : "Completed";
            const bgColorClass = task.status === 0 ? "bg-primary" : "bg-success";
            const taskCard = $(`
            <div class="card mb-4 w-100">  
                <div class="${bgColorClass} bg-opacity-50 m-0 p-2">
                   <h5 class="card-title text-white ">${task.name}</h5>
                </div>
                <div class="m-2">
                  <p class="card-text">${task.description}</p>
                  <p class="card-text">${statusText}</p>
                  </div>
                    <button class="btn btn-light details-button" data-project-id="${task.id}">
                        Manage task
                    </button>
              
            </div>`);

            taskCard.find(".details-button").click(() => {
                const taskId = task.id;
                const projectId = project.id;
                const url = `/Project/${projectId}/ProjectTask`
            });

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
                    console.log("xd")
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
