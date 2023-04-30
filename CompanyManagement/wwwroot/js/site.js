const RenderProjects = (projects, container) => {
    container.empty();

    for (const project of projects) {
        let statusText;
        switch (project.status) {
            case 0:
                statusText = 'Not started';
                break;
            case 1:
                statusText = 'In progress';
                break;
            case 2:
                statusText = 'Completed';
                break;
            default:
                statusText = 'Unknown';
        }

        const projectCard = $(`
            <div class="card mb-4 w-100 bg-opacity-10" style="cursor: pointer;"onmouseover="this.classList.add('bg-primary', 'border-primary')" onmouseout="this.classList.remove('bg-primary', 'border-primary')">
                <div class="card-body">
                    <h5 class="card-title">${project.name}</h5>
                    <p class="card-text">${project.description}</p>
                    <p class="card-text">${statusText}</p>
                </div>
            </div>`);

        projectCard.click(() => {
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
