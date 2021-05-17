
$(document).ready(function () {
    $.ajax({ url: "https://localhost:64536/actors", type: "GET", success: getActors, error: actorError });
});
var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

var allActors;
function getActors(actors) {
    allActors = actors;
    $('#actorCards').empty();
    actors.forEach(actor => {
        let date = new Date(actor.dob);
        let dateOfBirth = months[date.getMonth()] + ' ' + date.getDate() + ', ' + date.getFullYear();
        let actorCardsHTML = `<div class="col-lg-3" id = ${actor.id}>
        <div class="card" style="width: 18rem;">
          <div class="card-body">
            <h5 class="card-title">${actor.name}</h5>
            <h6 class="card-subtitle mb-2 text-muted">${actor.gender}</h6><br>
            <p>${dateOfBirth}</p>
            <p class="card-text">${actor.bio}</p>
            <button class="btn btn-outline-warning my-2 my-sm-0" onclick = fillActor(${actor.id}) id = "${actor.id}" data-toggle="modal" data-target="#actorModal" >edit</button>
            <button class="btn btn-outline-danger my-2 my-sm-0" onclick = deleteActor(${actor.id}) id = "${actor.id}">delete</button>

          </div>
        </div>
      </div>

        </div>
    </div>`;
        $(".actorCards").append(actorCardsHTML);
    });
}


const deleteActor = (id) => {
    const url = "https://localhost:64536/actors/" + id
    $.ajax({
        url: url,
        type: "DELETE",
        success: function (data) {
            $.ajax({ url: "https://localhost:64536/actors/"+id, type: "DELETE", success: actorSuccessFunction, error: actorErrorFunction })
        },
        error: function (err) {
            window.alert(err.responseText)
        }
    });
}

function actorError(error)
{
    console.log(error);
}

function fillActor(id){
    localStorage.setItem('actorId',id);
    for(i=0;i<allActors.length;i++){
        if(allActors[i].id===id){
            idx=i;
            break;
        }
    }
    response = allActors[idx];
    $("#actorName").val(response.name);
    $("#actorDOB").val(response.dob);
    $("#actorGender").val(response.gender);
    $("#actorBio").val(response.bio);
    $("#editActorSubmit").attr("onclick",editActor());

}





function editActor()
{
  
    var id = localStorage.getItem('actorId');
    let putData=JSON.stringify({
        "name":$("#actorName").val(),
        "dob":(new Date($('#actorDOB').val())),
        "gender":$("#actorGender").val(),
        "bio":$("#actorBio").val(), 
        
    });

    $.ajax({
        url:"https://localhost:64536/actors/"+id,
        type:"PUT",
        data:putData,
        contentType:"application/json; charset=utf-8",
        success:function(response){
            alert("Movie updated successfully.");
            location.href="actors.html";
        },
        error:function(error){
            console.log(error);
        }
    });
}