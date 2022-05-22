class HomeWork {
  
    id = Math.ceil(Math.random()*100);
    
    constructor(homeWork, priority){
    this.homeWork = homeWork;
    this.priority = priority;
  }
}

export {HomeWork};