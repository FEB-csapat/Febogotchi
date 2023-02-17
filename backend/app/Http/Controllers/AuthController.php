<?php

namespace App\Http\Controllers;

use App\Http\Requests\AuthenticateRequest;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
class AuthController extends Controller
{
    
    public function authenticate(AuthenticateRequest $request)
    {
        $data = $request->validated();

        if(Auth::attempt($data)){
            // successful login 
           // $request->session()->regenerate();
            
            $token = Auth::user()->createToken('auth_token')->plainTextToken;

            return response()->json([
                "data" => ["token"=>$token]
            ],200);
        }
        else{
            // unsuccessful login 
            return  response()->json([
                "data"=>["message"=>"Sikertelen belépés"]
            ],401);
            
        }
    }

    public function logout(Request $request)
    {
        Auth::logout();
        $request->session()->invalidate();
        $request->session()->regenerateToken();
        return redirect()->route('home')->with('success',"Sikeres kiejelentkezés.");
    }
}
