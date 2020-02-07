
var pages = ['index.html', 'page2.html', 'page3.html', 'page4.html'];

var countdownElement = document.getElementById('countdown');
var actionBtn = document.getElementById('pause-run');
var intervalId = {};
var pageIndex = 0;

var remainingTime = 3;


function back() {
       
     document.location.href = pages[pageIndexPreview()];
}

function getPageIndex() {
     return parseInt(localStorage.getItem("pageIndex")) || 0;
}

function setPageIndex(i) {
     localStorage["pageIndex"] = i;
}

function pageIndexNext() {

     pageIndex = getPageIndex();
     pageIndex += 1;

     setPageIndex(pageIndex);

     console.log("next: " + getPageIndex());
     return pageIndex;
}

function pageIndexPreview() {
     pageIndex = getPageIndex();

     pageIndex = (pageIndex != 0)
          ? pageIndex - 1
          : pages.length - 1;

     setPageIndex(pageIndex);

     return pageIndex;
}


function pageTurning() {

     pageIndex = getPageIndex();

     if (pageIndex < pages.length - 1) {
          runCountdown();
     } else {
          generateQuery();
     }
}

function pauseCountdown() {

     clearInterval(intervalId);
     
     actionBtn.textContent = "старт";
     actionBtn.setAttribute('onclick', 'runCountdown ()');
}

function runCountdown() {

     actionBtn.textContent = "пауза";
     actionBtn.setAttribute('onclick', 'pauseCountdown ()');

     intervalId = setInterval(() => {

          countdownElement.textContent = remainingTime + ' сек.';

          remainingTime--;

          if (remainingTime < 0) {

               clearInterval(intervalId);

               document.location.href = pages[pageIndexNext()];
          }
     }, 1000);
}



function generateQuery() {
     var queryElement = document.getElementById('pageScrollingInfo');
     queryElement.textContent = "Прокрутка страниц завершена!";

     var br = document.createElement('br');
     queryElement.appendChild(br);

     var aRepeat = document.createElement('a');
     aRepeat.textContent = "Повторить прокрутку";
     aRepeat.href = 'index.html';
     queryElement.appendChild(aRepeat);

     var aExit = document.createElement('a');
     aExit.textContent = "Завершить просмотр";
     aExit.href = '#';
     aExit.onclick = 'window.close();'

     queryElement.appendChild(aExit);

}




