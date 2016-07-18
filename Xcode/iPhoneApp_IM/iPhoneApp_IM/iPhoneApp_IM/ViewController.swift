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
    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Do any additional setup after loading the view, typically from a nib.
        self.usernameTextField?.text = "@Test_User1"
        self.passwordTextField?.text = "password"
        
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
    
    @IBAction func loginTapped(sender: UIButton) {
        print("hi")
        
        if self.usernameTextField?.text == "Dave" {
            self.performSegueWithIdentifier("goTo_Inventory", sender: nil)
        }
        
    }
    
    @IBAction func clearTapped(sender: UIButton) {
        
    }


}

