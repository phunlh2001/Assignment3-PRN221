$(() => {
    LoadUsers();

    const connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on("LoadUsers", function () {
        LoadUsers();
    })

    function LoadUsers() {
        let tr = "";

        $.ajax({
            method: "GET",
            url: "/AppUsers/GetUsers",
            success: (result) => {
                let index = 1;
                $.each(result, (k, v) => {
                    if (v.email === "admin@gmail.com") {
                        //same as 'continue' in C#
                        return true;
                    }
                    tr += `<tr>
                               <td>${index++}</td>
                               <td>${v.email}</td>
                               <td>${v.fullName}</td>
                               <td>${v.address}</td>
                           </tr>`;
                });
                $("#bodyUser").html(tr);
            },
            error: (err) => {
                console.log(err)
            }
        })
    }
})