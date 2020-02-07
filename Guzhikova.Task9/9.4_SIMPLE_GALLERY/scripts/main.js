
var pages = ['index.html', 'page2.html', 'page3.html', 'page4.html'];

var countdownElement = document.getElementById('countdown');
var actionBtn = document.getElementById('pause-run');
var intervalId = {};

var remainingTime = 3;


function back() {
     var backElement = document.getElementById('back'); 

     if (getPageIndex() != 0) {
          window.history.back();
     } else {
          document.location.href = pages[pages.length - 1];
     }
}

function getPageIndex() {
     return parseInt(localStorage.getItem("pageIndex")) || 0;
}

function pageIndex() {

     var pageIndex = getPageIndex();
     pageIndex += 1;

     setPageIndex(pageIndex);

     return pageIndex;
}

function setPageIndex(i) {
     localStorage["pageIndex"] = i;
}

function runCountdown() {
console.log(getPageIndex());

     actionBtn.textContent = "pause";
     actionBtn.setAttribute('onclick', 'pauseCountdown ()');

     intervalId = setInterval(() => {
          countdownElement.textContent = remainingTime + ' сек.';
          remainingTime--;

          if (remainingTime < 0) {

               clearInterval(intervalId);

               var index = pageIndex();
               if (index < pages.length) {

                    document.location.href = pages[index];
               } else {
                    generateQuery();
               }

          }
     }, 1000);
}

function pauseCountdown() {
     clearInterval(intervalId);
     actionBtn.textContent = "run";
     actionBtn.setAttribute('onclick', 'runCountdown ()');
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




