class HomeWork {
  
  id = Math.ceil(Math.random()*100);
  
  constructor(homeWork, priority){
  this.homeWork = homeWork;
  this.priority = priority;
}}



class AppToDos {

  listHomework=[]
  formHomeWork = document.querySelector('#formHomeWork');
  filterInput = document.querySelector('#filterInput');
  output = document.querySelector('#output');
  
  constructor (){
    this.getLocalStorage()
    // this.formHomeWork.addEventListener('submit', (e)=>this.handleSubmit(e));
    // this.filterInput.addEventListener('keydown',(e) =>this.filterText(e));
    // this.filterInput.selectpriority.addEventListener('change',(e)=>this.filterP(e))   
    this.printLocalStorage();           
  }

  getLocalStorage(){
    const jsonHomeWork = localStorage.getItem('homework');
    if(!jsonHomeWork) {
      return;
    }
    const parseHomeWork = JSON.parse(jsonHomeWork);
    this.listHomework = parseHomeWork;
  } 

  AddLocalStorage(){
    const newHomeworkString = JSON.stringify(this.listHomework);
    localStorage.setItem('homework', newHomeworkString);
  }

  remove(id){
    this.listHomework = this.listHomework.filter((homeWork)=> homeWork.id !== id)
    this.AddLocalStorage();
    this.print();
  }

  print(){
    this.output.innerHTML = '';
    this.listHomework.forEach(({id,homeWork,priority}) => {
      const li = this.create(id,homeWork,priority)
    this.output.append(li);
    });
  }

  create(id,homeWork,priority){
    const li = document.createElement('li');
    switch (priority){
      case 'n': li.className ='bg-info m-1'; break;
      case 'i': li.className ='bg-primary m-1'; break;
      case 'u': li.className ='bg-warning m-1'; break;
      default:window.Error('algo falla'); break;
    }
    li.innerHTML = homeWork;
    const btnRemove = document.createElement('i');
    btnRemove.className = 'ms-auto bi bi-trash text-danger ';
    btnRemove.addEventListener('click', () => this.remove(id));
    li.append(btnRemove)
    return li
  }







}


const app = new AppToDos();