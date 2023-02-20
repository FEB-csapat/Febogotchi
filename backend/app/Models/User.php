<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;

use Illuminate\Foundation\Auth\User as Authenticatable;
use Spatie\Permission\Traits\HasRoles;
use Spatie\Permission\Models\Role;

use Laravel\Passport\HasApiTokens;

class User extends Authenticatable
{
    use HasFactory, HasApiTokens, HasRoles;

    protected $table = 'users';
    protected $primaryKey = 'id';

    public function assignUserRole()
    {
        $this->assignRole(Role::firstOrCreate(['name' => 'user']));
    }

    public function setAdminRole()
    {
        $this->assignRole(Role::firstOrCreate(['name' => 'admin']));
    }


    public function pets()
    {
        return $this->hasMany(Pet::class, "user_id");
    }

    protected $fillable = [
        "name", "password"
    ];

}
