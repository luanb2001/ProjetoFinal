using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class ControllerTag
    {
        public static Tag InserirTag(
            string Descricao
            )
        {
            if(String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição inválida");
            }

            return new Tag(Descricao);
        }

        public static Tag AtualizarTag(
            int Id,  
            string Descricao
            )
        {
            Tag tag = GetTag(Id);

            if(!String.IsNullOrEmpty(Descricao))
            {
                Descricao = Descricao;
            }

            Tag.AtualizarTag(
                Id,
                Descricao
            );

            return tag;
        }

        public static Tag RemoverItem(int Id)
        {
            Tag tag = GetTag(Id);
            Tag.RemoverTag(tag);
            return tag;
        }

        public static Tag GetTag(int Id)
        {
            Tag tag = (
                from Tag in Tag.GetTags()
                    where Tag.Id == Id
                    select Tag
            ).First();

            if(tag == null)
            {
                throw new Exception("Tag não encontrada");
            }

            return tag;
        }

        public static IEnumerable<Tag> VisualizarTag()
        {
            return Tag.GetTags();
        }
    }
}