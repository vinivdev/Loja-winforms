using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.DTO;

namespace Loja.DAL
{
    public class UsuarioDAL
    {
        /*Metodo cargaUsuario, retorna uma Lista de objetos usuario DTO 
         * (composto por vários atributos), vai até o BD e busca todos os usuários. 
         * Usamos o try e Catch caso dê  algum erro, retorna para a camada view 
         * Executar o método cargaUsuario (será criado na DAL) 
         * */

        public IList<usuario_DTO> cargaUsuario()
        {
            try
            {
                /*Conexão com BD  
                 * Seleciona todos os dados da tb_usuarios*/
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "SELECT*FROM tb_usuarios";
                CM.Connection = CON;

                SqlDataReader ER;
                IList<usuario_DTO> listUsuarioDTO = new List<usuario_DTO>();

                CON.Open();
                ER = CM.ExecuteReader();
                if (ER.HasRows)
                {
                    while (ER.Read())
                    {
                        usuario_DTO usu = new usuario_DTO();

                        /*nome dos objetos criados na DTO 
                         * Cada objeto criado é enviado para a lista, possibilitando 
                         * que no final vc tenha uma lista com vários usuários */
                        usu.cod_usuario = Convert.ToInt32(ER["cod_usuario"]);
                        usu.perfil = Convert.ToInt32(ER["perfil"]);
                        usu.cadastro = Convert.ToDateTime(ER["cadastro"]);
                        usu.nome = Convert.ToString(ER["nome"]);
                        usu.email = Convert.ToString(ER["email"]);
                        usu.login = Convert.ToString(ER["cadastro"]);
                        usu.senha = Convert.ToString(ER["senha"]);
                        usu.situacao = Convert.ToString(ER["situacao"]);
                        listUsuarioDTO.Add(usu);
                    }
                }
                return listUsuarioDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
