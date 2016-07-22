//
//  ViewController.swift
//  iPhoneApp_IM
//
//  Created by Brandon Bigelow on 7/12/16.
//  Copyright © 2016 Brandon Bigelow. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    
   
    @IBOutlet weak var usernameTextField: UITextField?
    @IBOutlet weak var passwordTextField: UITextField?
    
    
    /////////////////////////////
    
//    @IBOutlet weak var usernameTextField : UITextField? = UITextField()
//    @IBOutlet weak var passwordTextField : UITextField? = UITextField()
    
    
    /////////////////////
    override func viewDidLoad() {
        super.viewDidLoad()
        
        
        // Do any additional setup after loading the view, typically from a nib.
        self.usernameTextField?.text = ""
        self.passwordTextField?.text = ""
        
    }
    
    /**
     * Called when the user click on the view (outside the UITextField).
     */
    override func touchesBegan(touches: Set<UITouch>, withEvent event: UIEvent?) {
        self.view.endEditing(true)
    }
    
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
//   @IBAction func loginTapped(sender: UIButton)
//   {
//    
//        self.performSegueWithIdentifier("goTo_Inventory", sender: nil)
//    
//   }
    
    @IBAction func loginTapped(sender : UIButton) {
        
        if (usernameTextField!.text == ""  || passwordTextField!.text == "")
        {
            print("Sign in failed. Empty characters")
        }
        else if(usernameTextField?.text == "test" && passwordTextField?.text == "password")
        {
            self.performSegueWithIdentifier("goTo_Inventory", sender: nil)
        }
        else {
            print("You shouldn't see this")
        }
    }

    
    
    @IBAction func clearTapped(sender: UIButton) {
       
        self.usernameTextField?.text = "";
        self.passwordTextField?.text = "";
        
    }


}

