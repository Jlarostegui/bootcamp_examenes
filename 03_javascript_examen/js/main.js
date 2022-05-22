class HomeWork {
  
  id = Math.ceil(Math.random()*100);
  
  constructor(homeWork, priority){
  this.homeWork = homeWork;
  this.priority = priority;
}
}


class AppToDos {

  listHomework=[];
  formHomeWork = document.querySelector('#formHomeWork');
  filterInput = document.querySelector('#filterInput');
  output = document.querySelector('#output');
  selectpriority = document.querySelector('#selectpriority')
  
  constructor (){
    this.firsLocalStorage()
    this.formHomeWork.addEventListener('submit', (e)=>this.handleSubmit(e));
    this.filterInput.addEventListener('keydown',(e) =>this.filterText(e));
    this.selectpriority.addEventListener('change',(e)=>this.filterP(e));             
  }

  firsLocalStorage(){
    const jsonHomeWork = localStorage.getItem('homework');
    if(!jsonHomeWork) {
      return;
    }
    const arrayimprimir = JSON.parse(jsonHomeWork);
    this.listHomework = arrayimprimir;
    this.onScreen(arrayimprimir);
  }

  updateLocalStorage(){
    const newHomeworkString = JSON.stringify(this.listHomework);
    localStorage.setItem('homework', newHomeworkString);
  }

  handleSubmit(e){
    e.preventDefault();
    
    if(!homeWork){
      return
    }
    this.add(homeWork,priority)
    this.formHomeWork.reset();
  }
  
  get(){
    const homeWork = this.formHomeWork.addHomework.value.trim();
    const priority = this.formHomeWork.priority.value;
    return {homeWork, priority};
  }

  add(homeWork, priority){
    const newHomework = new HomeWork(homeWork, priority);
    this.listHomework.push(newHomework);
    this.updateLocalStorage()
    const li = this.create(newHomework.id, homeWork, priority);
    this.output.append(li);
  } 
  
  remove(id){
    const newid = id;
    this.listHomework = this.listHomework.filter((homeWork)=> homeWork.id !== id)
    this.updateLocalStorage();
    this.onScreen();
  }
  
  onScreen(arrayimprimir){
    this.output.innerHTML = '';
    this.arrayimprimir.forEach(({id,homeWork,priority}) => {
      const li = this.create(id,homeWork,priority)
      this.output.append(li);
    });
  }

  create(id, homeWork, priority){
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
  
  filterP(e) {
      const arrayimprimir = this.listHomework.filter((homeWork)=> homeWork.priority === (this.selectpriority.value))
      this.onScreen(arrayimprimir)
      return arrayimprimir;
    }
    
  }

  filterText(e){
    if (e.key === 'backspace'){
    this.firsLocalStorage()
    }else{
    const letra = e.key;
    const arrayimprimir = this.listHomework.filter((homeWork)=> homeWork.homeWork.includes(letra));
    this.onScreen(arrayimprimir)
    return arrayimprimir;
    }}
1
  print(arrayimprimir){
    this.output.innerHTML='';
    arrayimprimir.forEach(({id,homeWork,priority}) =>{
      const li = this.create(id,homeWork,priority)
      this.output.append(li);
    })
  }

}


const app = new AppToDos();