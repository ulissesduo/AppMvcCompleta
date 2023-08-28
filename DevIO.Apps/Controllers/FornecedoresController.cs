using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevIO.App.Data;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using AutoMapper;
using DevIO.Business.Models;

namespace DevIO.App.Controllers
{
    //the base controller is a controller to inherit all the other controllers
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorRepository _fornecedorRepository;//get the repository interface to force implementation
        private readonly IMapper _mapper;//map the classes to pass through Xbase class and Xviewmodel class

        //This constructor receives the supplierRepository and Mapper interface to use on whole code.
        //the supplier interface forces all the methods of the interface to be implemented
        //the mapper is required to pass across the xbase class and xviewmodel class as need
        public FornecedoresController(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
             _fornecedorRepository = fornecedorRepository;
             _mapper = mapper;
        }
        //this code is the default method and throws the list (IEnumerable) of suppliers (i think so)
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos()));
        }
        //this method is responsible to bring informations of an specific supplier that is get by id
        public async Task<IActionResult> Details(Guid id)
        {
            //this variable stores the suppliers
            var fornecedorViewModel = await ObterFornecedorEndereco(id);
            //check if the supplier is null. If does, return not found of course.   
            if (fornecedorViewModel == null)
            {
                return NotFound();
            }
            //if it find the supplier, return the data according to properties of viewmodel
            return View(fornecedorViewModel);
        }

        //it returns a forms to register a supplier
        public IActionResult Create()
        {
            return View();
        }

        //httppost method send to the database the form data submited.       
        [HttpPost]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            
            //check if the model is valid. If it is not, return to index 
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
            //stores the data of supplier mapped.
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            //this line gets the "Add" method of the repository interface and pass the supplier as parameter to add new record
            await _fornecedorRepository.Adicionar(fornecedor);
            //finally redirect to index page after submit the form
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
           //stores the data related to specific supplier to update. 
            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);
            if (fornecedorViewModel == null)//check if the supplier is null or not
            {
                return NotFound();//return not found if it is null
            }
            return View(fornecedorViewModel);//if it is not null returns the view with the data related to supplier that the user wants to update
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return NotFound();
            

            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            
            await _fornecedorRepository.Atualizar(fornecedor);
            return RedirectToAction("Index");
        }

        //this metgod gets the supplier by id and brings the data related to it into a confirm delete page
        public async Task<IActionResult> Delete(Guid id)
        {
            //stores the data related to supplier retrieved by id
            var fornecedorViewModel = await ObterFornecedorEndereco(id);
            if (fornecedorViewModel == null)//check if it is null or not
            {
                return NotFound();//if it is null return not found
            }

            return View(fornecedorViewModel);//if it is not null returns the confirm page to delete with some data related to supplier
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //stores the data of supplier that the user wants to delete retrieved by id
            var fornecedorViewModel = await ObterFornecedorEndereco(id);
            //check if it is null or not
            if (fornecedorViewModel == null) return NotFound();
            //access the supplier repository to get the method to remove and pass the id as parameter to delete it
            await _fornecedorRepository.Remover(id);
            //after remove has been successfully, redirects to index page
            return RedirectToAction("Index");
        }
        
        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id) 
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }
        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id) 
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id)); 
        }

    }
}
