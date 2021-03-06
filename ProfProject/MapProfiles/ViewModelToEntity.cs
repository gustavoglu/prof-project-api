using AutoMapper;
using ProfProject.Entidades;
using ProfProject.ViewModels.Materias;
using ProfProject.ViewModels.Professores;

namespace ProfProject.MapProfiles
{
    public class ViewModelToEntity : Profile
    {
        public ViewModelToEntity()
        {
            CreateMap<MateriaViewModel, Materia>();
            CreateMap<MateriaFiltroViewModel, Materia>();
            CreateMap<Materia, MateriaFiltroViewModel>();

            CreateMap<ProfessorViewModel, Professor>();
            CreateMap<ProfessorDiaViewModel, ProfessorDia>();
            CreateMap<ProfessorMateriaViewModel, ProfessorMateria>();

        }
    }
}
