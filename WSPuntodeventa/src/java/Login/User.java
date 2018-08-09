/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Login;

/**
 *  
 * @author mara_
 */
public class User {
    private int idUsuario;
    private String password;
    private int permiso;
    
    public User(int idUsuario, String password, int permiso){
        this.idUsuario = idUsuario;
        this.password = password;
        this.permiso = permiso;
    }
    
    public int getidUsuario() {
        return idUsuario;
    }

    public void setidUsuario(int idUsuario) {
        this.idUsuario = idUsuario;
    }
    
    public String getpassword() {
        return password;
    }

    public void setpassword(String password) {
        this.password = password;
    }
    
    public int getpermiso() {
        return permiso;
    }

    public void setpermiso(int permiso) {
        this.permiso = permiso;
    }
}
