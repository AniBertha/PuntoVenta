/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package WS;

import Login.Login;
import Login.User;
import Usuario.CRUD_Usuario;
import Usuario.Usuario;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import static java.lang.Float.parseFloat;
import static java.lang.Integer.parseInt;
import java.lang.reflect.Type;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

/**
 *
 * @author Jose Antonio
 */
@WebService(serviceName = "ServidorWeb")
public class ServidorWeb {
    @WebMethod(operationName = "cargarUsuario")
    public String cargar() {
        return getDatarUsuarios("Cargar","0");
    }
     @WebMethod(operationName = "altaUsuario")
    public String insertar(@WebParam(name="json")String json) {
        return getDataUsuarios("Insertar",json);
    }
    @WebMethod(operationName = "bajaUsuario")
    public String eliminar(@WebParam(name="json")String json) {
        return getDataUsuarios("Eliminar",json);
    }
    @WebMethod(operationName = "actualizarUsuario")
    public String actualizar(@WebParam(name="json")String json) {
        return getDataUsuarios("Actualizar",json);
    }
    public String getDataUsuarios(String accion, String json){
        Gson gson = new Gson();
        CRUD_Usuario db = new  CRUD_Usuario();
        Type tipoObjeto = new TypeToken<List <Usuario>>(){}.getType();
        ArrayList<Usuario> usuario = gson.fromJson(json,tipoObjeto);
        Usuario p = usuario.get(0);
        try{
            if(accion == "Insertar")
                db.altaUsuario(p);
            else if (accion == "Eliminar")
                db.bajaUsuario(p);
            else if (accion == "Actualizar")
                db.actualizarUsuario(p);
            return "Accion exitosa.";
        }
        catch(Exception ex){
            return ex.getMessage();
        } 
    }
    public String getDatarUsuarios(String accion,String id){
        Gson gson = new Gson();
        ResultSet rs=null;
        CRUD_Usuario db = new CRUD_Usuario();
        try{
            if(accion == "Cargar")
                rs = db.consulta();
            ArrayList<Usuario> anim = new ArrayList();
            Usuario var_temp;
            while(rs.next()){
                var_temp = new Usuario(parseInt(rs.getString(1)),rs.getString(2),rs.getString(3),rs.getString(4),rs.getString(5),rs.getString(6),rs.getString(7),rs.getString(8),parseInt(rs.getString(9)));
                anim.add(var_temp);
            }
            String formatoJSON = gson.toJson(anim);
            return formatoJSON;
        }
        catch(Exception ex){
            return ex.getMessage();
        }
    }
    //////////////////////////
    @WebMethod(operationName = "buscarLogin")
    public String buscarLogin(@WebParam(name="id")int id,@WebParam(name="password")String password) {
        return getDatarLogin("Buscar",id, password);
    }
    public String getDatarLogin(String accion,int id, String password){
        Gson gson = new Gson();
        ResultSet rs=null;
        Login db = new Login();
        try{
            if(accion == "Buscar")
                rs = db.Buscar(id, password);
            ArrayList<User> anim = new ArrayList();
            User var_temp;
            while(rs.next()){
                var_temp = new User(parseInt(rs.getString(1)),rs.getString(2));
                anim.add(var_temp);
            }
            String formatoJSON = gson.toJson(anim);
            return formatoJSON;
        }
        catch(Exception ex){
            return ex.getMessage();
        }
    }
}
