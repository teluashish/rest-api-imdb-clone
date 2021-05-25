$(document).ready(function () {
    $.ajax({ url: "https://localhost:64536/producers", type: "GET", success: getProducers, error: producerError });
    $('form').submit((event) => {
        event.preventDefault();
    });
});

var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

const getProducers = (producers) => {
    $('#producerCards').empty();
    producers.forEach(producer => {
        let date = new Date(producer.dob);
        let dateOfBirth = months[date.getMonth()] + ' ' + date.getDate() + ', ' + date.getFullYear();
        let producerCard = 
        `<div class="col mb-4" id = ${producer.id}>
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">${producer.name}</h5>
                    <h6 class="card-subtitle mb-2 text-muted">${producer.gender}</h6><br>
                    <p>${dateOfBirth}</p>
                    <p class="card-text">${producer.bio}</p>

                    <button class="btn btn-outline-warning my-2 my-sm-0" onclick = fillProducer(${producer.id}) id = "${producer.id}" data-toggle="modal" data-target="#producerModal">edit</button>
                    <button class="btn btn-outline-danger my-2 my-sm-0" onclick = deleteProducer(${producer.id}) id = "${producer.id}">delete</button>
                </div>
            </div>
        </div>`;
        $(".producerCards").append(producerCard);
    });
}

const producerError = (error) => window.alert(error);

const deleteProducer = (id) => {
    $.ajax({
        url: "https://localhost:64536/producers/" + id,
        type: "DELETE",
        success: function (data) {
            window.alert('producer deleted successfully');   //data = id // tom
            location.href="producers.html";
        },
        error: error =>  window.alert(error.responseText)
    });
}


export const getProducerById = (id) => {
    producer = null
    $.ajax({
        url: "https://localhost:64536/producers/" + id,
        type: "GET",
        success: (data) => {
            producer = data
        },
        error: error =>  window.alert(error.responseText)
    });
    return producer;
}


const fillProducer = (id) => {
    localStorage.setItem('producerId',id);
    $.ajax({
        url: "https://localhost:64536/producers/" + id,
        type: "GET",
        success: function (producer) {
            $("#producerName").val(producer.name);
            $("#producerDOB").val(producer.dob);
            $("#producerGender").val(producer.gender);
            $("#producerBio").val(producer.bio);
            $("#producerSubmitEdit").attr("onclick",editProducer());
        },
        error: error =>  window.alert(error.responseText)
    });

}



const editProducer = () => {
    var id = localStorage.getItem('producerId');
    let producerData=JSON.stringify({
        "name":$("#producerName").val(),
        "dob":(new Date($('#producerDOB').val())),
        "gender":$("#producerGender").val(),
        "bio":$("#producerBio").val(), 
        
    });

    $.ajax({
        url:"https://localhost:64536/producers/"+id,
        type:"PUT",
        data:producerData,
        contentType:"application/json; charset=utf-8",
        success:function(response){
            window.alert("Producer updated successfully.");
            location.href="producers.html";
        },
        error: error =>  window.alert(error.responseText)
    });
}



const addProducer = () =>  {
    var producer = JSON.stringify(
        {
            "name": $("#producerName").val(),
            "gender": $("#producerGender").val(),
            "dob": $("#producerDOB").val(),
            "bio": $("#producerBio").val()
        });

    $.ajax({
        url: "https://localhost:64536/producers",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: producer,
        success: function () {
            window.alert("Producer added successfully.");
            $('#addProducerClose').trigger("click");
            location.href="producers.html";
        },
        error: error =>  window.alert(error.responseText),
        async: false
    });
}


