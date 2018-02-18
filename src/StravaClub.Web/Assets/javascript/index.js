import '../stylesheets/index.sass';

 document.addEventListener("DOMContentLoaded", () => {
     if ('serviceWorker' in navigator ) {
         navigator.serviceWorker.register('service-worker.js');
     }
 });