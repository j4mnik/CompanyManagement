const RenderProjects = (projects, container) => {
    container.empty();

    for (const project of projects) {
        const projectCard = $(`
            <div class="card mb-4 w-100">
                <div class="card-body">
                    <h5 class="card-title">${project.name}</h5>
                    <p class="card-text">${project.description}</p>
                    <button class="btn btn-primary details-button" data-project-id="${project.id}">
                        View details
                    </button>
                </div>
            </div>`);

        projectCard.find(".details-button").click(() => {
            const projectId = project.id;
            const url = `/Project/${projectId}/Details`;
            window.location.href = url;
        });

        container.append(projectCard);
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