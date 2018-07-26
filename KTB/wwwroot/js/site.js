// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// close question generate div
function CloseGenerator() {
    var x = document.getElementById("GameGenerator");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}




// clock

function getTimeRemaining(endtime) {
    var t = Date.parse(endtime) - Date.parse(new Date());

    var miliseconds = Math.floor(t / 1000);
    var seconds = Math.floor((t / 1000) % 60);
    var minutes = Math.floor((t / 1000 / 60) % 60);
    // var hours = Math.floor((t / (1000 * 60 * 60)) % 24);
    // var days = Math.floor(t / (1000 * 60 * 60 * 24));
    return {
      'total': t,
    //   'days': days,
    //   'hours': hours,
      'minutes': minutes,
      'seconds': seconds,
      'miliseconds': miliseconds
    };
  }
  
  function initializeClock(id, endtime) {
    var clock = document.getElementById(id);
    // var daysSpan = clock.querySelector('.days');
    // var hoursSpan = clock.querySelector('.hours');
    var minutesSpan = clock.querySelector('.minutes');
    var secondsSpan = clock.querySelector('.seconds');
    var milisecondsSpan = clock.querySelector('.miliseconds');

  
    function updateClock() {
      var t = getTimeRemaining(endtime);
  
    //   daysSpan.innerHTML = t.days;
    //   hoursSpan.innerHTML = ('0' + t.hours).slice(-2);
      minutesSpan.innerHTML = ('0' + t.minutes).slice(-2);
      secondsSpan.innerHTML = ('0' + t.seconds).slice(-2);
      milisecondsSpan.innerHTML = ('0' + t.miliseconds).slice(-2);
        
      // stops the interval
      if (t.total <= 0) {
        clearInterval(timeinterval);
      }
    }
    // update the interval
    updateClock();
    // var timeinterval = setInterval(updateClock, 1000);
    var timeinterval = setInterval(updateClock, 1);

  }
  
//   var deadline = new Date(Date.parse(new Date()) + 15 * 24 * 60 * 60 * 1000);
var deadline = new Date(Date.parse(new Date()) + 60 * 60 * 1000);

  initializeClock('clockdiv', deadline);