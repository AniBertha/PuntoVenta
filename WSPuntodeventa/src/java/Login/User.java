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
    
    public User(int idUsuario, String password){
        this.idUsuario = idUsuario;
        this.password = password;
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
}
