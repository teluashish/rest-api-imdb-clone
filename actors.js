$(document).ready(function () {
    $.ajax({ url: "https://localhost:64536/actors", type: "GET", success: getActors, error: actorError });
    $('form').submit((event) => {
        event.preventDefault();
    });
});

var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

const getActors = (actors) => {
    $('#actorCards').empty();
    console.log(actors);
    actors.forEach(actor => {
        let date = new Date(actor.dob);
        let dateOfBirth = months[date.getMonth()] + ' ' + date.getDate() + ', ' + date.getFullYear();
        let actorCard = 
        `<div class="col mb-4" id = ${actor.id}>
            <div class="card"">
                <div class="card-body">
                    <h5 class="card-title">${actor.name}</h5>
                    <h6 class="card-subtitle mb-2 text-muted">${actor.gender}</h6><br>
                    <p>${dateOfBirth}</p>
                    <p class="card-text">${actor.bio}</p>

                    <button class="btn btn-outline-warning my-2 my-sm-0" onclick = fillActor(${actor.id}) id = "${actor.id}" data-toggle="modal" data-target="#actorModal">edit</button>
                    <button class="btn btn-outline-danger my-2 my-sm-0" onclick = deleteActor(${actor.id}) id = "${actor.id}">delete</button>
                </div>
            </div>
        </div>`;
        $(".actorCards").append(actorCard);
    });
}

const actorError = (error) => window.alert(error);

const deleteActor = (id) => {
    $.ajax({
        url: "https://localhost:64536/actors/" + id,
        type: "DELETE",
        success: function (data) {
            window.alert('actor deleted successfully');   //data = id // tom
            location.href="actors.html";
        },
        error: error =>  window.alert(error.responseText)
    });
}


const fillActor = (id) => {
    localStorage.setItem('actorId',id);
    $('#actorModalLongTitle').text("Edit Actor Details");
    $('#add-actor').attr('onsubmit','editActor()');

    $.ajax({
        url: "https://localhost:64536/actors/" + id,
        type: "GET",
        success: function (actor) {
            $("#actorName").val(actor.name);
            $("#actorDOB").val(actor.dob);
            $("#actorGender").val(actor.gender);
            $("#actorBio").val(actor.bio);
        },
        error: error =>  window.alert(error.responseText)
    });

}



const editActor = () => {
    window.alert($('#add-actor').attr('onsubmit'));
    var id = localStorage.getItem('actorId');
    window.alert(id);
    let actorData=JSON.stringify({
        "name":$("#actorName").val(),
        "dob":(new Date($('#actorDOB').val())),
        "gender":$("#actorGender").val(),
        "bio":$("#actorBio").val(), 
        
    });
    window.alert(actorData);

    $.ajax({
        url:"https://localhost:64536/actors/"+id,
        type:"PUT",
        data:actorData,
        contentType:"application/json; charset=utf-8",
        success:function(response){
            window.alert("Movie updated successfully.");
        
        },
        error: error =>  window.alert(error.responseText)
    });
    window.alert('s');
}


const addActor = () =>  {
    var actor = JSON.stringify(
        {
            "name": $("#actorName").val(),
            "gender": $("#actorGender").val(),
            "dob": $("#actorDOB").val(),
            "bio": $("#actorBio").val()
        });

    $.ajax({
        url: "https://localhost:64536/actors",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: actor,
        success: function () {
            window.alert("Actor added successfully.");
            $('#addActorClose').trigger("click");
            location.href="actors.html";
        },
        error: error =>  window.alert(error.responseText),
        async: false
    });
}