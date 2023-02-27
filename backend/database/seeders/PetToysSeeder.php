<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class PetToysSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('toys')->insert([
            'title'=>'Csirke',
            'funpoints' => 1,
            'description'=>'Csipogós csirke, ellenállhatatlanúl ínycsiklandó'
        ]);
    }
}
