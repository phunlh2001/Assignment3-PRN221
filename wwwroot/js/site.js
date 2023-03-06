//$(() => {
//    LoadData();

//    const connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
//    connection.start();

//    connection.on("LoadPosts", () => {
//        LoadData();
//    })

//    LoadData();

//    function LoadData() {
//        let tr = "";

//        $.ajax({
//            method: "GET",
//            url: "/Posts/GetPosts",
//            success: (result) => {
//                $.each(result, (k, v) => {
//                    tr += `<tr>
//                               <td>${v.Title}</td>
//                               <td>${v.content}</td>
//                               <td>${v.postCategory}</td>

//                               <td>
//                                   <a href='../Posts/Edit?id=${v.id}'>Edit</a> | 
//                                   <a href='../Posts/Details?id=${v.id}'>Details</a> | 
//                                   <a href='../Posts/Delete?id=${v.id}'>Delete</a>
//                               </td>
//                           </tr>`;
//                });
//                $("#tableBody").html(tr);
//            },
//            error: (err) => {
//                console.log(err)
//            }
//        })
//    }
//})