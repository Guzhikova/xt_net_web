// &#9658;

var pages = ['index.html','page2.html','page3.html', 'page4.html'];
var index = getPageIndex ();

function setPageIndex (i)
{
     console.log('onLoad = ' + getPageIndex ());
     localStorage.setItem("pageIndex", i);  
}

function getPageIndex ()
{
     var result = localStorage.getItem("pageIndex");

     console.log(result);

     return (result != null) ? parseInt(result) : 0;
}

function allToRight() {

     var countdownElement = document.getElementById('countdown');   
   
     var remainingTime = 5;
     
     
     

     var intervalId = setInterval(() => {
          
          countdownElement.textContent =  remainingTime;
          remainingTime--;
console.log('index = ' + index);
        if (remainingTime === 0 && index < pages.length) {
  
     
         localStorage["pageIndex"] = index++;

          document.location.href = pages[index];
          
          clearInterval(intervalId);
          }
        }, 1000);       

}

function pause()
{
     clearInterval(intervalId);
}