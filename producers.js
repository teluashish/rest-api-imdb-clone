
$(document).ready(function () {
    $.ajax({ url: "https://localhost:64536/producers", type: "GET", success: getProducers, error: producerError });
});
var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

var allProducers;
function getProducers(producers) {
    allProducers = producers;
    $('#producerCards').empty();
    producers.forEach(producer => {
        let date = new Date(producer.dob);
        let dateOfBirth = months[date.getMonth()] + ' ' + date.getDate() + ', ' + date.getFullYear();
        let producerCardsHTML = `<div class="col-lg-3" id = ${producer.id}>
        <div class="card" style="width: 18rem;">
          <div class="card-body">
            <h5 class="card-title">${producer.name}</h5>
            <h6 class="card-subtitle mb-2 text-muted">${producer.gender}</h6><br>
            <p>${dateOfBirth}</p>
            <p class="card-text">${producer.bio}</p>
            <button class="btn btn-outline-warning my-2 my-sm-0" onclick = fillProducer(${producer.id}) id = "${producer.id}" data-toggle="modal" data-target="#producerModal" >edit</button>
            <button class="btn btn-outline-danger my-2 my-sm-0" onclick = deleteProducer(${producer.id}) id = "${producer.id}">delete</button>

          </div>
        </div>
      </div>

        </div>
    </div>`;
        $(".producerCards").append(producerCardsHTML);
    });
}


const deleteProducer = (id) => {
    const url = "https://localhost:64536/producers/" + id
    $.ajax({
        url: url,
        type: "DELETE",
        success: function (data) {
            $.ajax({ url: "https://localhost:64536/producers/"+id, type: "DELETE", success: getActors, error: producerError })
            location.href="producers.html";
        },
        error: function (err) {
            window.alert(err.responseText)
        }
    });
}

function producerError(error)
{
    console.log(error);
}

function fillProducer(id){
    localStorage.setItem('producerId',id);
    for(i=0;i<allProducers.length;i++){
        if(allProducers[i].id===id){
            idx=i;
            break;
        }
    }
    response = allProducers[idx];
    console.log(response);
    $("#producerName").val(response.name);
    $("#producerDOB").val(response.dob);
    $("#producerGender").val(response.gender);
    $("#producerBio").val(response.bio);
    $("#editProducerSubmit").attr("onclick",editProducer());

}





function editProducer()
{
  
    var id = localStorage.getItem('producerId');
    let putData=JSON.stringify({
        "name":$("#producerName").val(),
        "dob":(new Date($('#producerDOB').val())),
        "gender":$("#producerGender").val(),
        "bio":$("#producerBio").val(), 
        
    });

    $.ajax({
        url:"https://localhost:64536/producers/"+id,
        type:"PUT",
        data:putData,
        contentType:"application/json; charset=utf-8",
        success:function(response){
            alert("Movie updated successfully.");
            location.href="producers.html";
        },
        error:function(error){
            console.log(error);
        }
    });
}