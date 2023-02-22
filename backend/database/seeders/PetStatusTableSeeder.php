<?php

namespace Database\Seeders;

use App\Models\PetStatus;
use Illuminate\Database\Seeder;
use Illuminate\Support\Carbon;

class PetStatusTableSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        PetStatus::factory()->create([
            'id' => 1,
            'status' => "idle",
            'duration' => null
        ]);
        PetStatus::factory()->create([
            'id' => 2,
            'status' => "hunt",
            'duration' => Carbon::createFromTime(5, 0, 0)
        ]);
        PetStatus::factory()->create([
            'id' => 3,
            'status' => "play",
            'duration' => Carbon::createFromTime(3, 0, 0)
        ]);
        PetStatus::factory()->create([
            'id' => 4,
            'status' => "cure",
            'duration' => Carbon::createFromTime(7, 0, 0)
        ]);
        PetStatus::factory()->create([
            'id' => 5,
            'status' => "eat",
            'duration' => Carbon::createFromTime(2, 0, 0)
        ]);
        PetStatus::factory()->create([
            'id' => 6,
            'status' => "sleep",
            'duration' => Carbon::createFromTime(9, 0, 0)
        ]);


    }
}
