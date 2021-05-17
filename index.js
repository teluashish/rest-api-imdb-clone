

$(document).ready(function(){

    $.ajax({url:"https://localhost:64536/actors",type:"GET",success:actorSuccess,error:actorError});
    $.ajax({ url: "https://localhost:64536/producers", type: "GET", success: producerSuccess, error: producerError });

    $.ajax({ url: "https://localhost:64536/movies", type: "GET", success: movieSuccessFunction, error: movieErrorFunction });
    $("#actorDOB").attr("max",new Date().toISOString().split("T")[0]);
    $("#producerDOB").attr("max",new Date().toISOString().split("T")[0]);
});





var allProducers;

function assignProducer(producers){
    allProducers = producers;
}

function getProducerById(pid){
    for(i=0;i<allProducers.length;i++){
        if(allProducers[i].id==pid)return allProducers[i].name;
    }
  

}

var moviess ;
function movieSuccessFunction(response) {

     moviess = response;
    $('#movieCards').empty();
    response.forEach(movie => {
        let movieGenres = [];
        movie.genres.forEach(genre => {
            movieGenres.push(genre.name);
        });
        let movieActors = [];
        movie.actors.forEach(actor => {
            movieActors.push(actor.name);
        });
        let producer = getProducerById(movie.producerId);

        $("#movieId").innerHTML = movie.id;
        

       
        let movieCardsHTML = `
        <div class="col-lg-3"> 
        <div class="card" style="width: 18rem;border-radius:25px;position:relative;margin:10%">
          
          <img class="bd-placeholder-img card-img-top" width="100%" height="180" src="${movie.coverImage}" aria-label="Placeholder: Image cap" preserveAspectRatio="xMidYMid slice" role="img"><rect width="100%" height="100%" fill="#868e96"/></img>
        
          <div class="card-body">
            <h5 class="card-title">${movie.name}</h5>
            <h6 class="card-subtitle mb-2 text-muted"> --  ${movieGenres.join(", ")}</h6><br><br>
            <p class="card-text">${movie.plot}</p>
          </div>
          <ul class="list-group list-group-flush">
            <li class="list-group-item">Release: ${movie.year} </li>
            <li class="list-group-item">Producer: ${producer}</li>
            <li class="list-group-item">Cast: ${movieActors.join(", ")} </li>
          </ul>
          <div class="card-body">
          <button type="button" class="btn btn-ghost-primary" onclick="fillMovie(${movie.id})" data-toggle="modal" data-target="#movieModal">Edit</button>
          <button type="button" class="btn btn-ghost-danger" onclick="deleteMovie(${movie.id})">Delete</button>
          </div>
        </div>
        </div>`

        $(".movieCards").append(movieCardsHTML);
    });

    $.ajax({ url: "https://localhost:64536/producers", type: "GET", success: assignProducer, error: producerError });
}

function movieErrorFunction(error) {
    console.log(error);
}



function addActor() {
    
        var o = JSON.stringify(
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
            data: o,
            success: function () {
                window.alert("success");
                $('#addActorClose').trigger("click");
                $.ajax({ url: "https://localhost:64536/actors", type: "GET", success: actorSuccess, error: actorError });
            },
            error: function (error) {
                console.log(error);
            },
            async: false
        });
        $.ajax({ url: "https://localhost:64536/actors", type: "GET", success: actorSuccessFunction, error: actorErrorFunction })
    
}

function addGenre() {

    var o = JSON.stringify(
        {
            "Name": $("#genreName").val(),
        });

    $.ajax({
        url: "https://localhost:64536/genres",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: o,
        success: function () {
            window.alert("success");
            $('#addGenreClose').trigger("click");
            $.ajax({ url: "https://localhost:64536/genres", type: "GET", success: genreSuccess, error: genreError });

        },
        error: function (error) {
            console.log(error);
        },
        async: false
    });
    $.ajax({ url: "https://localhost:64536/genres", type: "GET", success: genreSuccessFunction, error: genreErrorFunction })




}

function addProducer() {
    var o = JSON.stringify(
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
        data: o,
        success: function () {
            window.alert("success");
            $('#addProducerClose').trigger("click");
            $.ajax({ url: "https://localhost:64536/producers", type: "GET", success: producerSuccess, error: producerError });
        },
        error: function (error) {
            console.log(error);
        },
        async: false
    });
    $.ajax({ url: "https://localhost:64536/producers", type: "GET", success: producerSuccessFunction, error: producerErrorFunction })

}

const deleteMovie = (id) => {
    console.log('DELETE');

    const url = "https://localhost:64536/movies/" + id
    $.ajax({
        url: url,
        type: "DELETE",
        success: function (data) {
            
            // $.ajax({ url: "https://localhost:64536/movies", type: "GET", success: movieSuccessFunction, error: movieErrorFunction })
        },
        error: function (err) {
            console.log(err)
            window.alert(err.responseText)
        }
    });
}





function populateActorsList()
{
    let childs=[];
    actors.forEach(actor=>{
        childs.push(`<option value="${actor.id}">${actor.name}</option>`);
    });
    $("#editActors").html(childs.join(" "));

}



function actorSuccess(response)
{
    actors=response;
    populateActorsList();
}

function actorError(error)
{
    console.log(error);
}





function producerSuccess(response)
{
    producers=response;
    assignProducer(response);
    populateProducersList();
}

function producerError(error)
{
    console.log(error);
}

function populateProducersList()
{
    let childs=[`<option value="_">Producer</option>`];
    producers.forEach(producer=>{
        childs.push(`<option value="${producer.id}">${producer.name}</option>`);
    });
    $("#editProducer").html(childs.join(''));

}



function genreSuccess(response)
{
    genres=response;
    populateGenresList();
}

function genreError(error)
{
    console.log(error);
}

function populateGenresList()
{
    let childs=[];
    genres.forEach(genre=>{
        childs.push(`<option value="${genre.id}">${genre.name}</option>`)
    });
    $("#editGenres").html(childs.join(" "));

}




var fillMovie = (id) =>
{ 

    localStorage.setItem('testObject', id);
    let idx;
 
    console.log(moviess);
    for(i=0;i<moviess.length;i++){
        if(moviess[i].id===id){
            idx=i;
        console.log(moviess[i].id,id);
        break;
        }
    }
    response = moviess[idx];
    console.log(idx,response);
    $("#editMovieName").val(response.name);
    $("#editYear").val(response.year);
    $("#editProducer").val(response.producerId);
    response.actors.forEach(actor=>{
        $(`select[id="editActors"] option[value="${actor.id}"]`).attr("selected","selected");
        $("#editActors").trigger("change");
    });
    response.genres.forEach(genre=>{
        $(`select[id="editGenres"] option[value="${genre.id}"]`).attr("selected","selected");
        $("#editGenres").trigger("change");
    });
    $("#editPlot").val(response.plot);
   
    $("#editMovieSubmit").attr("onclick",editMovie());
}

function movieError(error)
{
    console.log(error);
}

function editMovie()
{
  
    var id = localStorage.getItem('testObject');
    let putData=JSON.stringify({
        "name":$("#editMovieName").val(),
        "year":(new Date($('#editYear').val())).getFullYear(),
        "plot":$("#editPlot").val(),
        "coverImage":"",
        "producerId":parseInt($("#editProducer").val(),10),
        "movieActorMappingString":$("#editActors").val().join(","),
        "movieGenreMappingString":$("#editGenres").val().join(",")
        
        
    });

    $.ajax({
        url:"https://localhost:64536/movies/"+id,
        type:"PUT",
        data:putData,
        contentType:"application/json; charset=utf-8",
        success:function(response){
            alert("Movie updated successfully.");
            location.href="index.html";
        },
        error:function(error){
            console.log(error);
        }
    });
}