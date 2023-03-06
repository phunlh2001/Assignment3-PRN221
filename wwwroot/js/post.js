$(() => {
    LoadData();

    const connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on("LoadPosts", () => {
        LoadData();
    })

    LoadData();

    function LoadData() {
        let tr = "";

        $.ajax({
            method: "GET",
            url: "/Posts/GetPosts",
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
                               <td>${v.title ?? ""}</td>
                               <td>${v.createdDate ?? ""}</td>

                               <td>
                                   <a href='../Posts/Details?id=${v.id}' class="btn btn-secondary">
                                        <i class="fa fa-eye"></i>
                                   </a>
                               </td>
                           </tr>`;
                });
                $("#tableBody").html(tr);
            },
            error: (err) => {
                console.log(err)
            }
        })
    }
})