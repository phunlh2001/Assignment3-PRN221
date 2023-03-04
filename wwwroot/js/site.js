$(() => {
    LoadData();

    const connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on("LoadPosts", () => {
        LoadData();
    })

    function LoadData() {
        let tr = "";

        $.ajax({
            method: "GET",
            url: "/Posts/GetPosts",
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
                               <td>${v.Title}</td>
                               <td>${v.Content}</td>
                               <td>${v.PublishStatus}</td>
                               <td>${v.PostCategory}</td>
                               <td>${v.Author}</td>

                               <td>
                                   <a href='../Posts/Edit?id=${v.PostID}'>Edit</a> | 
                                   <a href='../Posts/Details?id=${v.PostID}'>Details</a> | 
                                   <a href='../Posts/Delete?id=${v.PostID}'>Delete</a>
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