<?php

namespace App\Http\Controllers;

use App\Http\Requests\LoginRequest;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use App\Models\User;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Validator;

class AuthController extends Controller
{

    public function register (Request $request) {
        $validator = Validator::make($request->all(), [
            'name' => 'required|string|max:20',
            'password' => 'required|string|min:5|max:255',
        ]);
        if ($validator->fails())
        {
            return response(['errors'=>$validator->errors()->all()], 422);
        }

        $request['password'] = Hash::make($request['password']);
        
        $user = User::create($request->toArray());
        $user->assignUserRole();

        $token = $user->createToken('auth_token')->accessToken;
        $response = ['token' => $token];
        return response($response, 200);
    }

    public function login(LoginRequest $request)
    {
        $validator = Validator::make($request->all(), [
            "name" => "required|string|min:4|max:20",
            "password" => "required|string|min:5|max:255"
        ]);
        

        if ($validator->fails())
        {
            return response(['errors'=>$validator->errors()->all()], 422);
        }

        $user = User::where('name', $request->name)->first();

        if ($user) {
            if (Hash::check($request->password, $user->password)) {
                $token = $user->createToken('auth_token')->accessToken;
                $response = ['token' => $token];
                return response($response, 200);
            } else {
                $response = ["message" => "Password mismatch"];
                return response($response, 422);
            }
        } else {
            $response = ["message" =>'User does not exist'];
            return response($response, 422);
        }
    }

    public function logout(Request $request)
    {
        $token = $request->user()->token();
        $token->revoke();
        $response = ['message' => 'You have been successfully logged out!'];

        return response($response, 200);
    }
}
