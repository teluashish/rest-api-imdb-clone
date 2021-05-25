$(document).ready(function () {


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