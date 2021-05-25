import { getProducerById } from "./producers.js";

$(document).ready(function () {
    $('.actorSelect').select2();
    $('.genreSelect').select2();
    $('.producerSelect').select2();
    $.ajax({ url: "https://localhost:64536/producers", type: "GET", success: producerSuccess, error: producerError });
    $.ajax({ url: "https://localhost:64536/actors", type: "GET", success: actorSuccess, error: actorError });
    $.ajax({ url: "https://localhost:64536/genres", type: "GET", success: genreSuccess, error: genreError });
    $.ajax({ url: "https://localhost:64536/movies", type: "GET", success: displayMovies, error: movieError });
    $("#actorDOB").attr("max",new Date().toISOString().split("T")[0]);
    $("#producerDOB").attr("max",new Date().toISOString().split("T")[0]);
    var firebaseConfig = {
        apiKey: "AIzaSyBfq9ELHwliZq_TBaAHjfGCmeweZQuoa0g",
        authDomain: "moviedb-260b6.firebaseapp.com",
        projectId: "moviedb-260b6",
        storageBucket: "moviedb-260b6.appspot.com",
        messagingSenderId: "292064391387",
        appId: "1:292064391387:web:b094e2ffd5c0882e1b9cfe"
      };
    // Initialize Firebase
    firebase.initializeApp(firebaseConfig);
    
    $('form').submit((event) => {
        event.preventDefault();
    });
});

var producers = [];
var actors = [];
var genres = [];
let movieList;




function producerSuccess(response) {
    producers = response;
    let childs = [];
    producers.forEach(producer => {
        childs.push(`<option value="${producer.id}" >${producer.name}</option>`);
    });
    $('#editProducer').empty()
    $("#editProducer").html(childs.join(" "));

}

function actorSuccess(response) {
    console.log(response);
    actors = response;
    let childs = [];
    actors.forEach(actor => {
        childs.push(`<option value="${actor.id}">${actor.name}</option>`);
    });
    $('#editActors').empty()
    $("#editActors").html(childs.join(" "));
}



function genreSuccess(response) {
    console.log(response);
    genres = response;
    let childs = [];
    genres.forEach(genre => {
        childs.push(`<option value="${genre.id}">${genre.name}</option>`)
    });
    $('#editGenres').empty()
    $("#editGenres").html(childs.join(" "));

}






function movieError(error) {
    window.alert('movie error: '+error);
}
function addMovie() {

            let formData=new FormData();
            let files=$("#movieImageUpload").prop('files');
            console.log(formData,files);
            let poster=files[0];
            formData.append("file",poster,poster.name);
    
       
        $.ajax({
            url: "https://localhost:64536/movies/upload",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: formData,
            contentType:false,
            processData: false,
            success: function (response) {
                console.log(response);
                let movie = JSON.stringify(
                    {
                        "name": $("#movieName").val(),
                        "year": $('#movieRelease').val(),
                        "plot": $("#moviePlot").val(),
                        "coverImage": response,
                        "producerId":parseInt($("#editProducer").val(),10),
                        "movieActorMappingString":$("#editActors").val().join(","),
                        "movieGenreMappingString":$("#editGenres").val().join(","),

                    });

                    $.ajax({
                        url:"https://localhost:64536/movies",
                        type:"POST",
                        data:movie,
                        contentType:"application/json; charset=utf-8",
                        success:function(response){
                            alert("Adding movie succesfully completed.");
                            console.log(movie);
                            location.href="index.html";
                        },
                        error:function(error)
                        {
                            console.log(error);
                        }
                    });
            },
            error: function (error) {
                window.alert("error");
            },
            async: false
        }); 

}


const deleteMovie = (id) => {
    $.ajax({
        url: "https://localhost:64536/movies/" + id,
        type: "DELETE",
        success: function (data) {
            window.alert('movie deletion successful');
        },
        error: function (error) {
            window.alert(error.responseText)
        }
    });
}


function displayMovies(response) {

    movieList = response;
    $('.movieCards').empty();
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
        
        let movieCardsHTML = `
        <div class="col mb-4"> 
            <div id="${movie.id}" class="card">
            <img src="${movie.coverImage}"></img>
        
            <div class="card-body">
                <h5 class="card-title">${movie.name}</h5>
                <h6 class="card-subtitle mb-2 text-muted"> ${movie.year}</h6><br><br>
                <p class="card-text">${movie.plot}</p>
            </div>
                <ul class="list-group list-group-flush" >
                    <li class="list-group-item">Producer: ${producer}</li>
                    <li class="list-group-item">Actors: ${movieActors.join(", ")} </li>
                    <li class="list-group-item">${movieGenres.join(", ")} </li>
                </ul>
                <div class="card-body">
                    <button type="button" class="btn btn-ghost-primary" onclick="fillMovie(${movie.id})" data-toggle="modal" data-target="#movieModal">Edit</button>
                    <button type="button" class="btn btn-ghost-danger" onclick="deleteMovie(${movie.id})">Delete</button>
                </div>
            </div>
            </div>
        </div>`

        $(".movieCards").append(movieCardsHTML);
    });

}


const fillMovie = (id) =>
{ 

    localStorage.setItem('movieId', id);
    let idx;

    for(i=0;i<movieList.length;i++){
        if(moviess[i].id===id){
            idx=i;
        console.log(moviess[i].id,id);
        break;
        }
    }
    response = movieList[idx];
    $("#movieName").val(response.name);
    $("#movieRelease").val(response.year);
    $("#editProducer").val(response.producerId);
    response.actors.forEach(actor=>{
        $(`select[id="editActors"] option[value="${actor.id}"]`).attr("selected","selected");
        $("#editActors").trigger("change");
    });
    response.genres.forEach(genre=>{
        $(`select[id="editGenres"] option[value="${genre.id}"]`).attr("selected","selected");
        $("#editGenres").trigger("change");
    });
    $("#moviePlot").val(response.plot);
   
    $("#editMovieSubmit").attr("onclick",editMovie());
}


function editMovie()
{
  
    var id = localStorage.getItem('movieId');
    let putData=JSON.stringify({
        "name":$("#movieName").val(),
        "year":$('#movieRelease').val(),
        "plot":$("#moviePlot").val(),
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

