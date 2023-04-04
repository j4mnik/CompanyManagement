const RenderProjects = (projects, container) => {
    container.empty();

    for (const project of projects) {
        container.append(
            `<div class="card mb-4 w-100">
           <div class="card-body">
            <h5 class="card-title">${project.name}</h5>
            <p class="card-text">${project.description}</p>
          </div>
        </div>`)
    }
}


const LoadProjects = () => {
    const container = $("#projects")
    const departmentId = container.data("id");

    $.ajax({
        url: `/Department/${departmentId}/Project`,
        type: 'get',
        success: function (data) {
            if (!data.length) {
                container.html("There are no projects for this department")
            } else {
                RenderProjects(data, container)
            }
        },
        error: function () {
            toastr["error"]("Something went wrong")
        }
    })
}